import axios from 'axios';

const path = '/collection';

export default {
    getCollections(user) {
<<<<<<< HEAD
        return axios.get(path + '/user/' + user)
=======

        return axios.get(path + '/user/' + user)

>>>>>>> 63feb98dacf993bd752b01446ed78e309a178241
    },

    addCollection(collection){
        return axios.post(path, collection)
    }
}