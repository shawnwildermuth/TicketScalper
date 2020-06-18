import ValidatableModel from "./validatableModel";

export default class Customer extends ValidatableModel {

  constructor(raw) {
    super();

    this.id = 0;
    this.firstName = "";
    this.lastName = "";
    this.phoneNumber = "";
    this.companyName = "";
    this.addressLine1 = "";
    this.addressLine2 = "";
    this.addressLine3 = "";
    this.cityTown = "";
    this.stateProvince = "";
    this.postalCode = "";
    this.country = "";

    if (raw !== undefined) {
      for (const key in raw) {
        if (this.hasOwnProperty(key)) {
          this[key] = raw[key];
        }
      }
    }
  }

  get isValid() {

    let success = super.isValid;

    success = success & this.validate(this.requiredValidator, "addressLine1", "Required");
    success = success & this.validate(this.requiredValidator, "cityTown", "Required");
    success = success & this.validate(this.requiredValidator, "stateProvince", "Required");
    success = success & (this.validate(this.requiredValidator, "postalCode", "Required") && 
                        this.validate(this.postalCodeValidator, "postalCode", "Invalid Postal Code"));
    success = success & this.validate(this.requiredValidator, "firstName", "Required");
    success = success & this.validate(this.requiredValidator, "lastName", "Required");

    return success
  }
}