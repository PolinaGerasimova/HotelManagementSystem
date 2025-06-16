<template>
  <v-container>
    <v-card class="pa-4">
      <v-card-title class="text-h5 mb-4">
        {{ isEdit ? 'Редактировать услугу' : 'Новая услуга' }}
      </v-card-title>

      <v-form @submit.prevent="submitForm" ref="form">
        <v-row>
          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.name"
              label="Название"
              :error-messages="errors.name"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.category"
              label="Категория"
              :error-messages="errors.category"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.price"
              label="Цена"
              type="number"
              :error-messages="errors.price"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.duration"
              label="Длительность (минуты)"
              type="number"
              :error-messages="errors.duration"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12">
            <v-textarea
              v-model="form.description"
              label="Описание"
              :error-messages="errors.description"
              required
            ></v-textarea>
          </v-col>
        </v-row>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="primary"
            type="submit"
            :loading="loading"
            :disabled="loading"
          >
            {{ isEdit ? 'Сохранить' : 'Создать' }}
          </v-btn>
          <v-btn
            color="secondary"
            @click="$router.push('/services')"
            :disabled="loading"
          >
            Отмена
          </v-btn>
        </v-card-actions>
      </v-form>
    </v-card>
  </v-container>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import axios from 'axios'

const route = useRoute()
const router = useRouter()
const form = ref({
  name: '',
  category: '',
  price: 0,
  duration: 0,
  description: ''
})

const errors = ref({})
const loading = ref(false)

const isEdit = computed(() => route.params.id !== undefined)

const loadService = async (id) => {
  try {
    const response = await axios.get(`/api/services/${id}`)
    const service = response.data
    form.value = {
      name: service.name,
      category: service.category,
      price: service.price,
      duration: service.duration,
      description: service.description
    }
  } catch (error) {
    console.error('Error loading service:', error)
  }
}

const submitForm = async () => {
  errors.value = {}
  loading.value = true

  try {
    const serviceData = {
      ...form.value,
      serviceId: isEdit.value ? parseInt(route.params.id) : 0
    }

    if (isEdit.value) {
      await axios.put(`/api/services/${route.params.id}`, serviceData)
    } else {
      await axios.post('/api/services', serviceData)
    }

    router.push('/services')
  } catch (error) {
    if (error.response?.data?.errors) {
      errors.value = error.response.data.errors
    } else {
      console.error('Error submitting form:', error)
    }
  } finally {
    loading.value = false
  }
}

onMounted(async () => {
  if (isEdit.value) {
    await loadService(route.params.id)
  }
})
</script> 