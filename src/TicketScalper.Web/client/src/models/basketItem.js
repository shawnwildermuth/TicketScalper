export default class BasketItem {
  constructor(ticket, show) {
    this.id = ticket.id;
    this.show = show.name;
    this.date = show.startDate;
    this.seat = ticket.seat;
    this.price = ticket.currentPrice;
  }
}