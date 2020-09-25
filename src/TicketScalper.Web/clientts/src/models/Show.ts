import Act from './Act';
import Ticket from './Ticket';
import Venue from './Venue';

export default interface Show {
  id: number;
  name: string;
  startDate: Date;
  length: number;
  isGeneralAdmission: boolean;
  soldOut: boolean;
  venue: Venue;
  acts: Array<Act>;
  tickets?: Array<Ticket>
}

