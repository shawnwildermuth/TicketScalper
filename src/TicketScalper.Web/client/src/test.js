class Foo {
  test() {
    console.log("Hello");
  }
}

class Bar extends Foo {
  constructor() {
    super();
  }


}

let x = new Bar();
x.test();