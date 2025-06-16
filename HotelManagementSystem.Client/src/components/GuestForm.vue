<template>
  <v-container>
    <v-card class="pa-4">
      <v-card-title class="text-h5 mb-4">
        {{ isEdit ? 'Редактировать гостя' : 'Новый гость' }}
      </v-card-title>

      <v-form @submit.prevent="submitForm" ref="form">
        <v-row>
          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.firstName"
              label="Имя"
              :error-messages="errors.firstName"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.lastName"
              label="Фамилия"
              :error-messages="errors.lastName"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.email"
              label="Email"
              type="email"
              :error-messages="errors.email"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.phone"
              label="Телефон"
              :error-messages="errors.phone"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.passportNumber"
              label="Номер паспорта"
              :error-messages="errors.passportNumber"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.address"
              label="Адрес"
              :error-messages="errors.address"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12">
            <v-textarea
              v-model="form.notes"
              label="Примечания"
              :error-messages="errors.notes"
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
            @click="$router.push('/guests')"
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
  firstName: '',
  lastName: '',
  email: '',
  phone: '',
  passportNumber: '',
  address: '',
  notes: ''
})

const errors = ref({})
const loading = ref(false)

const isEdit = computed(() => route.params.id !== undefined)

const loadGuest = async (id) => {
  try {
    const response = await axios.get(`/api/guests/${id}`)
    const guest = response.data
    form.value = {
      firstName: guest.firstName,
      lastName: guest.lastName,
      email: guest.email,
      phone: guest.phone,
      passportNumber: guest.passportNumber,
      address: guest.address,
      notes: guest.notes
    }
  } catch (error) {
    console.error('Error loading guest:', error)
  }
}

const submitForm = async () => {
  errors.value = {}
  loading.value = true

  try {
    const guestData = {
      ...form.value,
      guestId: isEdit.value ? parseInt(route.params.id) : 0
    }

    if (isEdit.value) {
      await axios.put(`/api/guests/${route.params.id}`, guestData)
    } else {
      await axios.post('/api/guests', guestData)
    }

    router.push('/guests')
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
    await loadGuest(route.params.id)
  }
})
</script> 