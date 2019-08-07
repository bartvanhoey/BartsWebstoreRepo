import { BartsWebstoreTemplatePage } from './app.po';

describe('BartsWebstore App', function() {
  let page: BartsWebstoreTemplatePage;

  beforeEach(() => {
    page = new BartsWebstoreTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
