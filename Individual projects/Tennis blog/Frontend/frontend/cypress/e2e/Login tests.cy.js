/// <reference types="Cypress" />

describe('Login correct player credentials test',() =>{
  it('Types correct player credentials logs in and navigates to profile', () => {
    // cy.viewport(1920, 1080)
    
    cy.visit('http://localhost:3000/')

    cy.contains('Log in').click()

    cy.url().should('include', '/login')

    cy.get('input#email.login-form__input').type('testing@mail.com')
    cy.get('input#email.login-form__input').should('have.value', 'testing@mail.com')

    cy.get('input#password.login-form__input').type(123)
    cy.get('input#password.login-form__input').should('have.value', 123)

    cy.contains('Log In').click()

    cy.url().should('not.include', 'login')
    cy.url().should('include', '/')

    cy.contains('Profile').click()
    cy.url().should('include', '/profile')
  })
})

describe('Login correct admin credentials test',() =>{
  it('Types correct admin credentials logs in and navigates to dashboard', () => {
    //cy.viewport(1920, 1080)
    
    cy.visit('http://localhost:3000/')

    cy.contains('Log in').click()

    cy.url().should('include', '/login')

    cy.get('input#email.login-form__input').type('admin@mail.com')
    cy.get('input#email.login-form__input').should('have.value', 'admin@mail.com')

    cy.get('input#password.login-form__input').type(123)
    cy.get('input#password.login-form__input').should('have.value', 123)

    cy.contains('Log In').click()

    cy.url().should('not.include', 'login')
    cy.url().should('include', '/')

    cy.contains('Dashboard').click()
    cy.url().should('include', '/admin')
  })
})

describe('Login incorrect credentials test',() =>{
  it('Types correct wrong credentials and gets alert', () => {
    //cy.viewport(1920, 1080)
    
    cy.visit('http://localhost:3000/')

    cy.contains('Log in').click()

    cy.url().should('include', '/login')

    cy.get('input#email.login-form__input').type('testing@mail.com')
    cy.get('input#email.login-form__input').should('have.value', 'testing@mail.com')

    cy.get('input#password.login-form__input').type(1)
    cy.get('input#password.login-form__input').should('have.value', 1)

    cy.contains('Log In').click()

    cy.on('window:alert', (message) => {
      expect(message).to.equal('Login failed! Check your email and password!');
    });

    cy.url().should('include', 'login')
  })
})