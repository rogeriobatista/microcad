import Sequelize, { Model } from 'sequelize';

class TBLDadosdatmail extends Model {
   static init(sequelize) {
      super.init(
         {
            nmail: {
               type: Sequelize.STRING,
               primaryKey: true,
            },
            ndata: Sequelize.STRING,
            nhora: Sequelize.STRING,
            nvxx: Sequelize.STRING,
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLDadosdatmail;
