import axios, { AxiosInstance } from "axios";
import store from "@/store";
declare function getTicketScalperBaseApiUrl(): string;

export default function createHttp(secured: boolean = true) : AxiosInstance {

  const base = getTicketScalperBaseApiUrl();

  if (secured) {
    return axios.create({
      baseURL: base,
      headers: { "Authorization": `bearer ${store.state.token}`}
    });
  } else {
    return axios.create({
      baseURL: base 
    });
  }
} 
