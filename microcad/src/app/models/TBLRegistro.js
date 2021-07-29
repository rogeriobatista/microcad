import Sequelize, { Model } from 'sequelize';

class TBLRegistro extends Model {
   static init(sequelize) {
      super.init(
         {
            nserie: {
               type: Sequelize.STRING,
               primaryKey: true,
            },
            tipo: Sequelize.STRING,
            versao: Sequelize.STRING,
            cliente: Sequelize.STRING,
            uf: Sequelize.STRING,
            cgc: Sequelize.STRING,
            email: Sequelize.STRING,
            serial: Sequelize.STRING,
            verant: Sequelize.STRING,
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLRegistro;
