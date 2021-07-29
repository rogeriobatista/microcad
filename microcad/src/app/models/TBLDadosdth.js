import Sequelize, { Model } from 'sequelize';

class TBLDadosdth extends Model {
   static init(sequelize) {
      super.init(
         {
            nserie0: {
               type: Sequelize.STRING,
               primaryKey: true,
            },
            cname: Sequelize.STRING,
            uname: Sequelize.STRING,
            ndata: Sequelize.STRING,
            nhora: Sequelize.STRING,
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLDadosdth;
