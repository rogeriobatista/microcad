import Sequelize, { Model } from 'sequelize';

class TBLDadosins000 extends Model {
   static init(sequelize) {
      super.init(
         {
            id: {
               type: Sequelize.INTEGER,
               primaryKey: true,
               autoIncrement: true,
            },
            nvxx: Sequelize.STRING,
            uname: Sequelize.STRING,
            cname: Sequelize.STRING,
            ndata: Sequelize.STRING,
            nhora: Sequelize.STRING,
            udata: Sequelize.STRING,
            uhora: Sequelize.STRING,
            totd: Sequelize.INTEGER,
            exe: Sequelize.STRING,
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLDadosins000;
