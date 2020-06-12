export function dateFormat(val) {
  let date = new Date(val);
  return date.toLocaleDateString();
}

export default {
  dateFormat
};