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
    this.userId = "";
    
    // IF DEBUG
    raw = raw ? raw :  {
      firstName: "Bob",
      lastName: "Smith",
      phoneNumber: "404-555-1212",
      addressLine1: "123 Main Street",
      cityTown: "Atlanta",
      stateProvince: "GA",
      postalCode: "30303"
    };


    if (raw !== undefined) {
      for (const key in raw) {
        if (this.hasOwnProperty(key)) {
          this[key] = raw[key];
        }
      }
    }
  }

  validate() {

    super.validate();
    
    let success = true;

    success = success & this.validateField(this.requiredValidator, "addressLine1", "Required");
    success = success & this.validateField(this.requiredValidator, "cityTown", "Required");
    success = success & this.validateField(this.requiredValidator, "stateProvince", "Required");
    success = success & (this.validateField(this.requiredValidator, "postalCode", "Required") && 
                        this.validateField(this.postalCodeValidator, "postalCode", "Invalid Postal Code"));
    success = success & this.validateField(this.requiredValidator, "firstName", "Required");
    success = success & this.validateField(this.requiredValidator, "lastName", "Required");

    this.isValid = success;
  }
}