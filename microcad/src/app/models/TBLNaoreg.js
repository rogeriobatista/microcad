import Sequelize, { Model } from 'sequelize';

class TBLNaoreg extends Model {
   static init(sequelize) {
      super.init(
         {
            id: {
               type: Sequelize.INTEGER,
               primaryKey: true,
               autoIncrement: true,
            },
            nserie0: Sequelize.STRING,
            uname: Sequelize.STRING,
            cname: Sequelize.STRING,
            ndata: Sequelize.STRING,
            nhora: Sequelize.STRING,
            ntipo: Sequelize.STRING,
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLNaoreg;
