export function dateFormat(val) {
  let date = new Date(val);
  return date.toLocaleDateString();
}


export function moneyFormat(val) {
  if (typeof(val) === "number") {
    return `$${val.toFixed(2)}`;
  }

  return val;
}

export default {
  dateFormat,
  moneyFormat
};