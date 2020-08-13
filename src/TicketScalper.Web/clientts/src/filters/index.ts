export function dateFormat(val:Date) {
  return val.toLocaleDateString();
}


export function moneyFormat(val:Number) {
  return `$${val.toFixed(2)}`;
}

export default {
  dateFormat,
  moneyFormat
};