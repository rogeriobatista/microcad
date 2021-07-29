import Sequelize, { Model } from 'sequelize';

class TBLAtualiza extends Model {
   static init(sequelize) {
      super.init(
         {
            nvxx: {
               type: Sequelize.STRING,
               primaryKey: true,
            },
            nvxxyy: Sequelize.STRING,
            ndata: Sequelize.STRING,
            vxx: Sequelize.STRING,
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLAtualiza;
