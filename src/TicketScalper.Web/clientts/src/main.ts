import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import { registerComponents } from './components/components';

const app = createApp(App);

registerComponents(app);

app.use(store)
   .use(router)
   .mount('#app');
