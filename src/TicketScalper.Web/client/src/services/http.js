import axios from "axios";
import store from "@/store";

export default function createHttp(secured) {
  // Default
  if (secured === undefined) secured = true;

  const base = "https://localhost:5999/"

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
