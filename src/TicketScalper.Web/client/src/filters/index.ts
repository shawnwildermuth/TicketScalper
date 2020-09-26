export function dateFormat(val:any) {
  return new Date(val).toLocaleDateString();
}


export function moneyFormat(val:Number) {
  return `$${val.toFixed(2)}`;
}

export default {
  dateFormat,
  moneyFormat
};