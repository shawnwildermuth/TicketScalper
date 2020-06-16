import WaitCursor from "./WaitCursor";
import RouteButton from "./RouteButton";
import ErrorSpan from "./ErrorSpan";

export function registerComponents(app) {
  app.component("WaitCursor", WaitCursor);
  app.component("RouteButton", RouteButton);
  app.component("ErrorSpan", ErrorSpan);
}

export default {
  WaitCursor,
  RouteButton
}