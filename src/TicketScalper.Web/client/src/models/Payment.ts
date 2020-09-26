export default interface Payment {
  creditCard: string;
  expirationMonth: number;
  expirationYear: number;
  postalCode: string;
  validationCode: string;
}