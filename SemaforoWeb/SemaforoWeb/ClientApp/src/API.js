const API = {
  providers: {
    APIurl: '/api/Catalog/Provider/',
    idField: 'providerId',
  },
  clients: {
    APIurl: '/api/Catalog/Client/',
    idField: 'clientId',
  },
  brands: {
    APIurl: '/api/Catalog/Brand/',
    idField: 'brandId',
  },
  login: {
    APIurl: '/api/Auth/Login',
    SocialUrl: '/api/Auth/SocialLogin',
  },
  registerUser: {
    APIurl: '/api/Auth/Register',
    ConfirmEmailUrl: '/api/Auth/ConfirmEmail?userId=#uid&code=#cd',
  },
}

export default API
