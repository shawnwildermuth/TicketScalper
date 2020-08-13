export default class BasketItem {
  id: number;
  show: string;
  date: Date;
  seat: string;
  price: string;

  constructor(ticket: any, show: any) {
    this.id = ticket.id;
    this.show = show.name;
    this.date = show.startDate;
    this.seat = ticket.seat;
    this.price = ticket.currentPrice;
  }
}