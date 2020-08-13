import { reactive, ref, Ref } from 'vue';
import { validate, ValidationError } from "class-validator";

export default abstract class BaseModel {

  public isValid: Ref<boolean>;
  public errors: Object;

  constructor() {
    this.isValid = ref(true), 
    this.errors = reactive({});
  }

  public async validate() {
    this.isValid.value = true;
    Object.keys(this.errors).forEach((key) => { delete (this as any)._errors[key]; });
    
    var result = await validate(this);
    if (result.length > 0) {
      this.isValid.value = false;
      for (let error of result) {
        for (const key in error.constraints) {
          if (Object.prototype.hasOwnProperty.call(error.constraints, key)) {
            const msg = error.constraints[key];
            (this as any).errors[error.property] = msg;
          }
        } 
      }
    } else {
      this.isValid.value = true;
    }
  }

}