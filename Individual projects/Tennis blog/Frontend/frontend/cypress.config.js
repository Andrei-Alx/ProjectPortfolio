const { defineConfig } = require("cypress");

module.exports = defineConfig({
  projectId: '5arj4f',
  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
      experimentalStudio: true
    },
  },
});
