import WaitCursor from "./WaitCursor.vue";
import RouteButton from "./RouteButton.vue";
import ErrorSpan from "./ErrorSpan.vue";
import { App } from 'vue';

export function registerComponents(app:App<Element>) {
  app.component("WaitCursor", WaitCursor);
  app.component("RouteButton", RouteButton);
  app.component("ErrorSpan", ErrorSpan);
}

export default {
  WaitCursor,
  RouteButton
}