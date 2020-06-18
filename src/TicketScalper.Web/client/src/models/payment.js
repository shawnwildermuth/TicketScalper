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

  get isValid() {

    const creditCardValidator = (val) => val.match(/^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$/);
    const monthValidator = (val) => {
      var parsed = Number.parseInt(val);
      return !isNaN(parsed) && parsed > 0 && parsed < 13;
    };
    const yearValidator = (val) => {
      const parsed = Number.parseInt(val);
      const today = new Date();
      return !isNaN(parsed) && parsed > (today.getFullYear() -  1) && parsed < (today.getFullYear() + 20);
    };
    const postalCodeValidator = (val) => val.match(/^[0-9]{5}(?:-[0-9]{4})?$/);
    const validationCodeValidator = (val) => val.match(/^[0-9]{3,4}$/);

    let success = super.isValid;

    if (!creditCardValidator(this.creditCard)) {
      success = false;
      this.errors["creditCard"] = "Invalid Credit Card";
    }

    if (!monthValidator(this.expirationMonth)) {
      success = false;
      this.errors["expirationMonth"] = "Invalid Month";
    }

    if (!yearValidator(this.expirationYear)) {
      success = false;
      this.errors["expirationYear"] = "Invalid Year";
    }

    if (!validationCodeValidator(this.validationCode)) {
      success = false;
      this.errors["validationCode"] = "Invalid Validation Code";
    }
    if (!postalCodeValidator(this.postalCode)) {
      success = false;
      this.errors["postalCode"] = "Invalid Postal Code";
    }

    return success
  }
}