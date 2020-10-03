import axios, { AxiosInstance } from "axios";
import store from "@/store";

export default function createHttp(secured: boolean = true) : AxiosInstance {

  const base = "http://localhost:8889/"

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
