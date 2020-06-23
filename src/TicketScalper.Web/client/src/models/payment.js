import ValidatableModel from "./validatableModel";

export default class Payment extends ValidatableModel {

  constructor(creditCard, expirationMonth, expirationYear, postalCode, validationCode) {
    super();
    this.creditCard = creditCard;
    this.expirationMonth = expirationMonth;
    this.expirationYear = expirationYear;
    this.postalCode = postalCode;
    this.validationCode = validationCode;
  }

  validate() {

    super.validate();

    const monthValidator = (val) => {
      var parsed = Number.parseInt(val);
      return !isNaN(parsed) && parsed > 0 && parsed < 13;
    };
    const yearValidator = (val) => {
      const parsed = Number.parseInt(val);
      const today = new Date();
      return !isNaN(parsed) && parsed > (today.getFullYear() -  1) && parsed < (today.getFullYear() + 20);
    };
    const validationCodeValidator = (val) => /^[0-9]{3,4}$/.test(val);

    let success = true;

    success = success & this.validateField(this.creditCardValidator, "creditCard", "Invalid Credit Card.");
    success = success & this.validateField(monthValidator, "expirationMonth", "Invalid Expiration Month.");
    success = success & this.validateField(yearValidator, "expirationYear", "Invalid Expiration Year.");
    success = success & this.validateField(validationCodeValidator, "validationCode", "Invalid Validation Code.");
    success = success & this.validateField(this.postalCodeValidator, "postalCode", "Invalid Postal Code.");

    this.isValid = success;
  }
}