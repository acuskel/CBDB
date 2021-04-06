import axios from 'axios';

const path = '/collection';

export default {
    getCollections() {
        return axios.get(path)
    },


}