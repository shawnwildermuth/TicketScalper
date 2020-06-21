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

  validateField(validator, fieldName, message) {
    if (!validator) {
      throw new Error(`The validator for ${fieldName} is undefined`);
    }
    let result = validator(this[fieldName]);
    if (!result) {
      this.errors[fieldName] = message;
    } 
    return result;
  }
}