import WaitCursor from "./WaitCursor";
import RouteButton from "./RouteButton";

export function registerComponents(app) {
  app.component("WaitCursor", WaitCursor);
  app.component("RouteButton", RouteButton);
}

export default {
  WaitCursor,
  RouteButton
}