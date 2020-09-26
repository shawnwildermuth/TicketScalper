export const creditCard = {
  $validator: value => {
    if (typeof value === 'undefined' || value === null || value === '') {
      return true
    }
    return /^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$/.test(value)
  },
  $message: "Must be a valid credit card number."
};

export const phone = {
  $validator: value => {
    if (typeof value === 'undefined' || value === null || value === '') {
      return true
    }
    return /^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$/.test(value)
  },
  $message: "Must be a valid phone number."
};

export const length = (length) => ({
  $validator: value => {
    if (typeof value === 'undefined' || value === null || value === '') {
      return true
    }
    return value?.length === length;
  }, $message: `Must be exactly ${length}characters long`
});