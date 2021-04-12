import axios from 'axios';

const path = '/collection';

export default {
    getCollections(userId) {
        return axios.get(path + '/user/' + userId)
    },

    addCollection(collection){
        return axios.post(path, collection)
    },

    getIssues(collectionId) {
        return axios.get(path + '/' + collectionId)
    },

    getPublicCollections() {
        return axios.get(path)
    },
}