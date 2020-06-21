import ValidatableModel from "./validatableModel";

export default class Credentials extends ValidatableModel {
  
  constructor() {
    super();
    this.username = "";
    this.password = "";
  }

  validate() {

    super.validate();

    let success = true;
    if (!this.username) {
      this.errors["username"] = "Username is required";
      success = false;
    } else if (this.username.length < 5) {
      this.errors["username"] = "Username should be > 5 characters";
      success = false;
    }

    if (!this.password) {
      this.errors["password"] = "Password is required";
      success = false;
    } else if (!this.password.match(/^(?=.*\d).{4,24}$/)){
      this.errors["password"] = "Password must be more complex";
      success = false;
    }

    this.isValid = success;
  
  }
}