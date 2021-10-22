require('dotenv/config');

module.exports = {
   dialect: 'mssql',
   host: process.env.DB_HOST,
   port: 1433,
   loggging: false,
  
   username: process.env.DB_USER,
   password: process.env.DB_PASS,
   database: process.env.DB_NAME,
   dialectOptions: {
      options: {
         requestTimeout: 300000,
         encrypt: true,
         validateBulkLoadParameters: true,
       }
   }, 
   define: {
      timestamps: false,
      underscored: true,
      underscoredAll: true,
      freezeTableName: true,

   },
};
