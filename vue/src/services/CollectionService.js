import axios from 'axios';

const path = '/collection';

export default {
    getCollections(user) {
        return axios.get(path + '/' + user)
    },

    addCollection(collection){
        return axios.post(path, collection)
    }


}