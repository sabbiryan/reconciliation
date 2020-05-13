import Vue from 'vue';
import App from './App.vue';
import BootstrapVue from 'bootstrap-vue';
import 'bootstrap';
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
//import VueCompositionApi from '@vue/composition-api';
import axios from 'axios';
import VueAxios from 'vue-axios';

Vue.config.productionTip = true;

Vue.use(BootstrapVue)
//Vue.use(VueCompositionApi);
Vue.use(VueAxios, axios);



new Vue({
    render: h => h(App)
}).$mount('#app');
