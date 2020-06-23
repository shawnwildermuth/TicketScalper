import { reactive, ref } from "vue";

export default class ValidatableModel {
  constructor() {
    this.errors = reactive({})
    this.isValid = ref(false);
  }

  validate() {
    this.isValid = true;
    Object.keys(this.errors).forEach((key) => { delete this.errors[key]; });
  }

  passwordValidator = (val) => /^([a-zA-Z0-9!@*#]{8,15})$/.test(val);
  postalCodeValidator = (val) => /^[0-9]{5}(?:-[0-9]{4})?$/.test(val);
  requiredValidator = (val) => val ? true : false;
  lengthValidator = (len) => (val) => val.length >= len;
  emailValidator = (val) => /^\S+@\S+$/.test(val);
  creditCardValidator = (val) => /^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$/.test(val);
   
  validateField(validator, fieldName, message) {
    if (!validator) {
      throw new Error(`The validator for ${fieldName} is undefined`);
    }
    let result = validator(this[fieldName]);
    if (!result) {
      this.errors[fieldName] = message;
    } 
    console.log(`${fieldName} validateField to ${result}`);
    return result;
  }
}