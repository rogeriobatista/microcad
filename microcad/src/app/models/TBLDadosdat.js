import Sequelize, { Model } from 'sequelize';

class TBLDadosdat extends Model {
   static init(sequelize) {
      super.init(
         {
            id: {
               type: Sequelize.INTEGER,
               primaryKey: true,
               autoIncrement: true,
            },
            nvxx: Sequelize.STRING,
            ndata: Sequelize.STRING,
            ntot: Sequelize.INTEGER,
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLDadosdat;
