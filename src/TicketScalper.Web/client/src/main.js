import { createApp } from 'vue';
import App from './App.vue'
import router from './router'
import store from './store'
import { registerComponents } from "./components";

let app = createApp(App);

registerComponents(app);

app.config.errorHandler = (error) => {
  store.commit("setError", error);
  throw error;
}

app.use(router)
  .use(store)
  .mount('#app')
