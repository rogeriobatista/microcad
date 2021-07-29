// const uuid = require('uuid/v4');

module.exports = {
   up: (queryInterface, Sequelize) => {
      return queryInterface.createTable('TBLRegistro', {
         nserie: {
            type: Sequelize.STRING(6),
            allowNull: false,
            primaryKey: true,
            unique: true,
         },
         tipo: {
            type: Sequelize.STRING(1),
         },
         versao: {
            type: Sequelize.STRING(3),
         },
         email: {
            type: Sequelize.STRING(100),
         },
         cliente: {
            type: Sequelize.STRING(255),
         },
         cgc: {
            type: Sequelize.STRING(14),
         },
      });
   },

   down: queryInterface => {
      return queryInterface.dropTable('TBLRegistro');
   },
};
