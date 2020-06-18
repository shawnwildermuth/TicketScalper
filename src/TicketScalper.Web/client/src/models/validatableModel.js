import { reactive } from "vue";

export default class ValidatableModel {
  constructor() {
    this.errors = reactive({})
  }

  get isValid() {
    Object.keys(this.errors).forEach((key) => { delete this.errors[key]; });
    return true;
  }

  postalCodeValidator = (val) => val.match(/^[0-9]{5}(?:-[0-9]{4})?$/);
  requiredValidator = (val) => val ? true : false;
  lengthValidator = (len) => (val) => val.length >= len;
  emailValidator = (val) => val.match(/(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/);

  validate(validator, fieldName, message) {
    if (!validator) {
      throw new Error(`The validator for ${fieldName} is undefined`);
    }
    console.info(`Validating ${fieldName}`);
    let result = validator(this[fieldName]);
    console.info(`Validated ${fieldName} as ${result}`);
    if (!result) {
      this.errors[fieldName] = message;
    } 
    return result;
  }
}