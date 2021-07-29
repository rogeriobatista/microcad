import Sequelize, { Model } from 'sequelize';

class TBLDadostxt extends Model {
   static init(sequelize) {
      super.init(
         {
            ncmd: {
               type: Sequelize.STRING,
               primaryKey: true,
            },
            ntot: Sequelize.INTEGER,
            ndata: Sequelize.STRING,
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLDadostxt;
