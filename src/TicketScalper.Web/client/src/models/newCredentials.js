import ValidatableModel from "./validatableModel";

export default class NewCredentials extends ValidatableModel {
  
  constructor() {
    super();
    this.email = "";
    this.password = "";
    this.confirmPassword = "";
  }

  get isValid() {
  
    let success = super.isValid;

    let passwordValidator = (val) => {
      return this.requiredValidator(val) && val.match(/^(?=.*\d).{4,24}$/);
    }


    let passwordConfirmationValidator = (val) => {
      return this.confirmPassword == this.password;
    }

    success = success & this.validate(this.emailValidator, "email", "Invalid email");
    success = success & this.validate(passwordValidator, "password", "Invalid password");
    success = success & this.validate(passwordConfirmationValidator, "confirmPassword", "Passwords must match");

    return success;
  
  }
}