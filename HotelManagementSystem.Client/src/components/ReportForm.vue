<template>
  <v-container>
    <v-card class="pa-4">
      <v-card-title class="text-h5 mb-4">
        {{ isEdit ? 'Редактировать отчет' : 'Новый отчет' }}
      </v-card-title>

      <v-form @submit.prevent="submitForm" ref="form">
        <v-row>
          <v-col cols="12" md="6">
            <v-select
              v-model="form.reportType"
              :items="reportTypes"
              label="Тип отчета"
              :error-messages="errors.reportType"
              required
            ></v-select>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.title"
              label="Заголовок"
              :error-messages="errors.title"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.generatedDate"
              label="Дата создания"
              type="date"
              :error-messages="errors.generatedDate"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-select
              v-model="form.generatedById"
              :items="users"
              item-title="fullName"
              item-value="userId"
              label="Создал"
              :error-messages="errors.generatedById"
              required
            ></v-select>
          </v-col>

          <v-col cols="12">
            <v-textarea
              v-model="form.content"
              label="Содержание"
              :error-messages="errors.content"
              required
            ></v-textarea>
          </v-col>

          <v-col cols="12">
            <v-textarea
              v-model="form.conclusion"
              label="Заключение"
              :error-messages="errors.conclusion"
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
            @click="$router.push('/reports')"
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
  reportType: '',
  title: '',
  generatedDate: new Date().toISOString().split('T')[0],
  generatedById: null,
  content: '',
  conclusion: ''
})

const errors = ref({})
const loading = ref(false)
const users = ref([])

const reportTypes = [
  { title: 'Финансовый', value: 'Financial' },
  { title: 'Загрузка', value: 'Occupancy' },
  { title: 'Услуги', value: 'Services' },
  { title: 'Обслуживание', value: 'Maintenance' },
  { title: 'Другое', value: 'Other' }
]

const isEdit = computed(() => route.params.id !== undefined)

const loadUsers = async () => {
  try {
    const response = await axios.get('/api/users')
    users.value = response.data
  } catch (error) {
    console.error('Error loading users:', error)
  }
}

const loadReport = async (id) => {
  try {
    const response = await axios.get(`/api/reports/${id}`)
    const report = response.data
    form.value = {
      reportType: report.reportType,
      title: report.title,
      generatedDate: report.generatedDate.split('T')[0],
      generatedById: report.generatedById,
      content: report.content,
      conclusion: report.conclusion
    }
  } catch (error) {
    console.error('Error loading report:', error)
  }
}

const submitForm = async () => {
  errors.value = {}
  loading.value = true

  try {
    const reportData = {
      ...form.value,
      reportId: isEdit.value ? parseInt(route.params.id) : 0
    }

    if (isEdit.value) {
      await axios.put(`/api/reports/${route.params.id}`, reportData)
    } else {
      await axios.post('/api/reports', reportData)
    }

    router.push('/reports')
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
  await loadUsers()
  if (isEdit.value) {
    await loadReport(route.params.id)
  }
})
</script> 