import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import { registerComponents } from './components/components';
import { VuelidatePlugin } from "@vuelidate/core";

const app = createApp(App);

registerComponents(app);

app.use(store)
   .use(router)
   .use(VuelidatePlugin)
   .mount('#app');
