describe('burgerplace spec', () => {
  const FRONTEND_URL = "bp-testing-kubecon-eu-25.ngrok.io";
  const BURGER_PLACE = "Dick's Drive-In";

  beforeEach(() => {
    cy.visit(FRONTEND_URL)
  })
  it('Visits Burger Places', () => {})
  it('finds "Add" button', () => {
    cy.get('a').contains('Add')
  })  
  it('clicks "Add" button', () => {
    cy.get('a').contains('Add').click()
  })
  it('enters burger place', () => {
    cy.get('a').contains('Add').click()
    cy.get('input[name=name]').type(BURGER_PLACE)

    cy.get('input[type=submit]').contains('Save').click()
    cy.get('table').contains(BURGER_PLACE)
  })
})