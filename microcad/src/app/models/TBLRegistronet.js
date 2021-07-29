import Sequelize, { Model } from 'sequelize';

class TBLRegistronet extends Model {
   static init(sequelize) {
      super.init(
         {
            nserie: {
               type: Sequelize.STRING,
               primaryKey: true,
            },
            nome: Sequelize.STRING,
            nomereg: Sequelize.STRING,
            programa: Sequelize.STRING,
            tipo: Sequelize.STRING,
            versao: Sequelize.STRING,
            nserieant: Sequelize.STRING,
            versaoant: Sequelize.STRING,
            serial: Sequelize.STRING,
            dataenv: Sequelize.STRING,
            data: Sequelize.STRING,
            valor: Sequelize.STRING,
            desconto: Sequelize.STRING,
            frete: Sequelize.STRING,
            pago: Sequelize.STRING,
            codrastre: Sequelize.STRING,
            rua: Sequelize.STRING,
            bairro: Sequelize.STRING,
            cidade: Sequelize.STRING,
            uf: Sequelize.STRING,
            cep: Sequelize.STRING,
            cgc: Sequelize.STRING,
            telefone: Sequelize.STRING,
            email: Sequelize.STRING,
            emailcc: Sequelize.STRING,
            obs: Sequelize.STRING,
         },
         {
            sequelize,
         }
      );

      return this;
   }
}

export default TBLRegistronet;
