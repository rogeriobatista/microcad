
module.exports = {
   up: QueryInterface => {
      return QueryInterface.bulkInsert('TBLRegistro', [
         {
            nserie: '123456',
            tipo: 'F',
            versao: 'V15',
            email: 'pbal@backware.com.br',
            cliente: 'Pierre Charles Balochini',
            cgc: '84549017791',
            
         },
         {
            nserie: '654321',
            tipo: 'J',
            versao: 'V16',
            email: 'pb@bf.srv.br',
            cliente: 'Backware Tecnologia Ltda',
            cgc: '02054532000137',
            
         },
         {
            nserie: '111111',
            tipo: 'F',
            versao: 'V15',
            email: 'felix@backware.com.br',
            cliente: 'Felix melo',
            cgc: '123456789010',
            
         },
         {
            nserie: '222222',
            tipo: 'J',
            versao: 'V12',
            email: 'felix@amicrocad.com.br',
            cliente: 'MicroCad LTDA',
            cgc: '22222222222',
            
         },
 
 
      ]);
   },

   down: () => {},
};
