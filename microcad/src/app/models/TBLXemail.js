import Sequelize, { Model } from 'sequelize';

class TBLXemail extends Model {
   static init(sequelize) {
      super.init(
         {
            id: {
               type: Sequelize.INTEGER,
               primaryKey: true,
               autoIncrement: true
            },
            nserie: Sequelize.STRING,
            email: Sequelize.STRING,
            data: Sequelize.STRING,
            origem: Sequelize.STRING
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLXemail;
