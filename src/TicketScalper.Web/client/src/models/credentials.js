export default class Credentials {
  
  constructor() {
    this.username = "";
    this.password = "";
  }

  isValid(errors) {
  
    Object.keys(errors).forEach(function (key) { delete errors[key]; });
  
    let success = true;

    if (!this.username) {
      errors["username"] = "Username is required";
      success = false;
    } else if (this.username.length < 5) {
      errors["username"] = "Username should be > 5 characters";
      success = false;
    }

    if (!this.password) {
      errors["password"] = "Password is required";
      success = false;
    } else if (!this.password.match(/^(?=.*\d).{4,24}$/)){
      errors["password"] = "Password must be more complex";
      success = false;
    }

    return success;
  
  }
}