
export default class NewCredentials {

  username: string;
  password: string;
  confirmPassword: string;

  constructor() {
    this.username = "";
    this.password = "";
    this.confirmPassword = "";
  }

  // validate() {
  
  //   super.validate();

  //   let passwordConfirmationValidator = (val) => {
  //     let result = this.confirmPassword == this.password;
  //     return result;
  //   }

  //   let success = true;

  //   success = success & this.validateField(this.requiredValidator, "username", "Required");
  //   success = success & this.validateField(this.emailValidator, "username", "Invalid email");
  //   success = success & this.validateField(this.passwordValidator, "password", "Password must be more complex.");
  //   success = success & this.validateField(passwordConfirmationValidator, "confirmPassword", "Passwords must match");
    
  //   this.isValid = success;
  
  // }
}