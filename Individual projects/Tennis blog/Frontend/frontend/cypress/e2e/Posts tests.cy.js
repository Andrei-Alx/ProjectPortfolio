// /// <reference types="Cypress" />

// describe('Login and add a post as favorite', () => {
//   it('Types correct player credentials logs in and adds a post as favorite', () => {
//     cy.viewport(1920, 1080)

//     cy.visit('http://localhost:3000/')

//     cy.contains('Log in').click()

//     cy.url().should('include', '/login')

//     cy.get('input#email.login-form__input').type('testing@mail.com')
//     cy.get('input#email.login-form__input').should('have.value', 'testing@mail.com')

//     cy.get('input#password.login-form__input').type(123)
//     cy.get('input#password.login-form__input').should('have.value', 123)

//     cy.contains('Log In').click()

//     cy.url().should('not.include', 'login')
//     cy.url().should('include', '/')

//     cy.contains('Highlights').click()
//     cy.url().should('include', '/highlights')

    
//   })
// })